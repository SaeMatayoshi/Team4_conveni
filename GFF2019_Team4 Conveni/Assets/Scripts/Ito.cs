using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ito : MonoBehaviour
{
    // 仲間のCollider内にいるかどうか
    bool Isarea = false;   
    public TouchInput touchInput;
    // 仲間の残り人数
    public Count count;

    public GameObject kumo;

    RaycastHit2D hitObject;

    bool Iscount; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ３人目を助けようとしたときの蜘蛛出現の処理
        if (count.Iscount == true)
        {
            Instantiate(
                kumo,
                gameObject.transform.position,
                Quaternion.identity
                );

            count.Iscount = false;
        }        
    }

    // 主人公が仲間のColliderにいる間
    private void OnTriggerStay2D(Collider2D collision)
    {
        Isarea = true;
        
        if (collision.gameObject.tag == "Player")
        {
            TouchInput.Started += info =>
            {
                if (Isarea)
                {
                    Vector2 tapPosition = touchInput.Position;
                    tapPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Collider2D collider2D = Physics2D.OverlapPoint(tapPosition);

                    if (collider2D)
                    {
                        RaycastHit2D hitObject = Physics2D.Raycast(tapPosition, Vector2.up);
                        if (hitObject.collider.gameObject.tag == "Friend")
                        {                          
                            hitObject.collider.gameObject.SetActive(false);                                                        
                            
                        }
                    }
                    Isarea = false;
                }                
            };
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Isarea = false;
    }
}
