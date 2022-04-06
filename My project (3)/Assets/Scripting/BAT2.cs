using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BAT2 : MonoBehaviour
{
    [SerializeField] private Transform player;
    //[SerializeField] float BatHight = 2f;
    [SerializeField] float speed = 2;
    SpriteRenderer sprite;
    private Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        //sprite = GetComponentInChildren<SpriteRenderer>();
        StartCoroutine(Attack());
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (player.position.x > transform.position.x)
        //{
        //    sprite.flipX = true;

        //}
        //else{
        //    sprite.flipX = false;
        //}

    }
    IEnumerator Attack()
    {
        Vector3 endPos = new Vector3(StartPos.x, StartPos.y, StartPos.z);
        bool IsFilight = true;
        float value = 0;

        while (true)
        {
            yield return null;
            if (IsFilight)
            {
                transform.position = Vector3.Lerp(StartPos, endPos, value);
            }
            else
            {
                transform.position = Vector3.Lerp(endPos, StartPos, value);
            }
            //Debug.Log("Move");
            value += (Time.deltaTime * speed);
            if (value > 1)
            {
                value = 0;
                IsFilight = !IsFilight;
            }
        }
    }
}
