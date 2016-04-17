using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickSoundScript : MonoBehaviour, IPointerClickHandler
{

    public AudioClip clickSound;
    public AudioSource audioSource;

    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSound);
    }
}
