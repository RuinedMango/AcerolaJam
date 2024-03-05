using UnityEngine;
using Ink.Runtime;

public class InkExternalFunctions : MonoBehaviour
{
    public void Bind(Story story, Gun gun)
    {
        story.BindExternalFunction("giveGun", (string gunName) => GiveGun(gunName, gun));
    }

    public void Unbind(Story story)
    {
        story.UnbindExternalFunction("giveGun");
    }

    public void GiveGun(string gunName, Gun gun)
    {
        if (gun != null)
        {
            switch (gunName)
            {
                case "fire_gun":
                    gun.fireRate = 0.01f;
                    gun.auto = true;
                    gun.bulletAmount = 10;
                    gun.bullet.GetComponent<Bullet>().delete = 0.1f;
                    break;
                case "ice_gun":
                    break;
            }
        }
        else
        {
            Debug.LogWarning("Tried to play emote, but emote animator was "
                + "not initialized when entering dialogue mode.");
        }
    }
}
