using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falls: MonoBehaviour
{
    private float FallDelay =1f;
    private float DestroyDelay = 2f;

    [SerializeField] private Rigidbody2D rb;
   
   private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Player")){
            StartCoroutine(Fall());
            PlatformManager.Instance.StartCoroutine("SpawnPlatform",
					new Vector2 (transform.position.x, transform.position.y));
        }
    }
   private IEnumerator Fall()
   {
    yield return new WaitForSeconds(FallDelay);
    rb.bodyType = RigidbodyType2D.Dynamic;
    Destroy(gameObject, DestroyDelay);
   }
     }
