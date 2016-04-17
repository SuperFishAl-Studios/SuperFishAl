using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEnterSoundScript : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip enterSound;
    public AudioSource audioSource;

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        audioSource.PlayOneShot(enterSound);
    }
}
