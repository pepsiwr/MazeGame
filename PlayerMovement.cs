using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Inventory inventory;
    public GameObject Hand;
    public InventorySlot iSlot;

    private IInventoryItem mCurrentItem = null;

    void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
    }

    void Update()
    {
        Movement();


        if (Input.GetKeyDown(KeyCode.E))
        {
            IInventoryItem item = inventory.ItemTop();
            print("Used item" + item);
            if (item != null)
            {
                if (mCurrentItem != null)
                {
                    DropCurrenItem();
                }
                inventory.UseItem(item);
                inventory.RemoveItem(item);
            }
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (mCurrentItem != null)
            {
                DropCurrenItem();
            }
        }
    }

    void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
            item.OnPickup();
        }
    }

    private void SetItemAvtive(IInventoryItem item, bool active)
    {
        GameObject currenItem = (item as MonoBehaviour).gameObject;
        currenItem.SetActive(active);
        
        currenItem.transform.parent = active ? Hand.transform : null; // ? = มั๊ย
        //currenItem.transform.position = new Vector3(0.362f, -0.1720001f, 0.46f);
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        if (mCurrentItem != null)
        {
            SetItemAvtive(mCurrentItem, false);
        }

        IInventoryItem item = e.Item;
        SetItemAvtive(item, true);
        mCurrentItem = e.Item;
    }

    public void DropCurrenItem()
    {
        //anim.SetInteger("Condition", 3);
        GameObject goItem = (mCurrentItem as MonoBehaviour).gameObject;
        goItem.SetActive(true);
        goItem.transform.parent = null;

        Rigidbody rbItem = goItem.AddComponent<Rigidbody>();
        if (rbItem != null)
        {
            rbItem.AddForce(transform.forward * 10.0f, ForceMode.Impulse);
            rbItem.AddForce(transform.up * 5.0f, ForceMode.Impulse);
            Invoke("DoDropItem", 2.0f);
        }
    }

    public void DoDropItem()
    {
        Destroy((mCurrentItem as MonoBehaviour).GetComponent<Rigidbody>());
        mCurrentItem = null;
    }
}
