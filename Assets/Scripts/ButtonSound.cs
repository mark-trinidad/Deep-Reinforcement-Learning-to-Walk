using UnityEngine;
using UnityEngine.UI;


public class ButtonSound : MonoBehaviour
{
    public AudioSource SFX;
    public AudioClip hoverfx;
    public AudioClip clickfx;

    public void HoverSound()
    {

        SFX.PlayOneShot(hoverfx);

    }

    public void ClickSound()
    {

        SFX.PlayOneShot(clickfx);
        
    }

}