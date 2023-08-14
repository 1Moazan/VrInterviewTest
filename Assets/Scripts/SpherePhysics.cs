using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using Random = UnityEngine.Random;

public class SpherePhysics : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable _interactable;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip [] audioClips;
    
    private Vector3 _initPos;
    private Quaternion _initRot;

    private void Start()
    {
        _initPos = rb.position;
        _initRot = rb.rotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out DropBox box))
        {
            if (!box.resetTable)
            {
                box.DropObject();
                audioSource.PlayOneShot(audioClips[Random.Range(0 , audioClips.Length)]);
                _interactable.interactionManager.CancelInteractableSelection(_interactable as IXRSelectInteractable);
                rb.isKinematic = true;
                StartCoroutine(ResetRb());
            }
            else
            {
                SceneManager.LoadScene("TestScene");
            }
        }
    }
    private IEnumerator ResetRb()
    {
        rb.position = _initPos;
        rb.rotation = _initRot;
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
    }
}
