using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] LayerMask target1, target5, ground;
    public GameLogic gameLogic;
    [SerializeField] Rigidbody rb;
    bool contact;
    Vector3 contactPoint,collisionObject;
    // Start is called before the first frame update
    void Start()
    {
        contact = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(Vector3 direction, float force)
    {
        rb.AddForce(direction * force,ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        contactPoint = collision.contacts[0].point;
        collisionObject = collision.transform.position;
        if (!contact)
        {
            contact = true;
            rb.isKinematic = true;
            if (collision.gameObject.tag == "Target")
            {
                if (Vector3.Distance(contactPoint, collisionObject) < 0.53)
                {
                    gameLogic.TargetHit(5);
                }
                else
                {
                    gameLogic.TargetHit(1);
                }
            }
            else if (collision.gameObject.tag == "Ground")
            {
                gameLogic.TargetHit(0);
            }
            StartCoroutine(DestroyArrow());
        }
    }

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(gameLogic.waitTime + 0.5f);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(contactPoint, 0.1f);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(collisionObject, 0.1f);
    }

}
