using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera playerCamera;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    private CharacterController controller;


    public Transform itemContainer;
    private Transform currentItem;
    public float dropForwardForce = 3f, dropUpwardForce = 2f;
    private bool equipped;
    private static bool slotFull;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<PlayerLook>().playerCam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        // Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if(inputManager.onFoot.Interact.triggered)
                    interactable.BaseInteract();
            }
        }
    }

    public void PickUp(Transform item)
    {
        if(!equipped)
        {
            currentItem = item;
            equipped = true;
            slotFull = true;

            Rigidbody rb = item.GetComponent<Rigidbody>();

            if (rb != null)
                Destroy(rb);

            CapsuleCollider coll = item.GetComponent<CapsuleCollider>();

            coll.isTrigger = true;

            currentItem.SetParent(itemContainer);
            currentItem.localPosition = Vector3.zero;
            currentItem.localRotation = Quaternion.identity;
            currentItem.localScale = Vector3.one;
        }
    }

    public void Drop()
    {
        if(equipped)
        {
            equipped = false;
            slotFull = false;

            currentItem.SetParent(null);

            Rigidbody rb = currentItem.GetComponent<Rigidbody>();
            if (rb == null)
            {
                currentItem.gameObject.AddComponent<Rigidbody>();
                rb = currentItem.GetComponent<Rigidbody>();
            }

            CapsuleCollider coll = currentItem.GetComponent<CapsuleCollider>();

            rb.isKinematic = false;
            rb.interpolation = RigidbodyInterpolation.Extrapolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            coll.isTrigger = false;

            rb.velocity = controller.velocity;

            rb.AddForce(playerCamera.transform.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(playerCamera.transform.up * dropUpwardForce, ForceMode.Impulse);

            float random = Random.Range(-1f, 1f);
            rb.AddTorque(new Vector3(random, random, random) * 10);
        }
    }
}
