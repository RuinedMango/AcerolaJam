using Ink.Runtime;
using System.Collections.Generic;
using UnityEngine;

public class DialogueVariables : MonoBehaviour
{
    public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }

    private Story globalVariableStory;
    private const string saveVariablesKey = "INK_VARIABLES";

    public DialogueVariables(TextAsset loadGlobalsJSON)
    {
        globalVariableStory = new Story(loadGlobalsJSON.text);
        if(PlayerPrefs.HasKey(saveVariablesKey))
        {
            string jsonState = PlayerPrefs.GetString(saveVariablesKey);
            globalVariableStory.state.LoadJson(jsonState);
        }

        variables = new Dictionary<string, Ink.Runtime.Object>();
        foreach(string name in globalVariableStory.variablesState)
        {
            Ink.Runtime.Object value = globalVariableStory.variablesState.GetVariableWithName(name);
            variables.Add(name, value);
            Debug.Log("Inited: " + name + " = " + value);
        }
    }

    public void SaveVariables()
    {
        if(globalVariableStory != null)
        {
            VariablesToStory(globalVariableStory);
            PlayerPrefs.SetString(saveVariablesKey, globalVariableStory.state.ToJson());
        }
    }

    public void StartListening(Story story)
    {
        VariablesToStory(story);
        story.variablesState.variableChangedEvent += VariableChanged;
    }

    public void StopListening(Story story)
    {
        story.variablesState.variableChangedEvent -= VariableChanged;
    }

    private void VariableChanged(string name, Ink.Runtime.Object value)
    {
        if(variables.ContainsKey(name))
        {
            variables.Remove(name);
            variables.Add(name, value);
        }
    }

    private void VariablesToStory(Story story)
    {  
        foreach(KeyValuePair<string, Ink.Runtime.Object> variable in variables)
        {
            story.variablesState.SetGlobal(variable.Key, variable.Value);
        }
    }
}
