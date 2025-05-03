using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private Coroutine messageCoroutine;

    public TextMeshProUGUI interactionText;
    public float messageDuration = 1f;

    public void ShowMessage(string message)
    {
        if (messageCoroutine != null) StopCoroutine(messageCoroutine);
        interactionText.text = message;
        interactionText.gameObject.SetActive(true);
        messageCoroutine = StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        interactionText.gameObject.SetActive(false);
    }
}