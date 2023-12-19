using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public float speed;
    public Transform target;
    // public Transform initial;
    public GameObject coinPrefab;
    public Camera cam;

    private void Start(){
        if (cam == null){
            cam = Camera.main;
        }
    }


    public void StartCoinMove(Vector3 _initial){
        //Vector3 initialPos = cam.ScreenToViewportPoint(new Vector3(initial.position.x,initial.position.y,initial.position.z * -1));
        Vector3 targetPos = cam.ScreenToViewportPoint(new Vector3(target.position.x,target.position.y,target.position.z * -1));

        GameObject _coin = Instantiate(coinPrefab,transform);

        StartCoroutine(MoveCoin(_coin.transform,_initial,targetPos));
    }

    IEnumerator MoveCoin(Transform obj, Vector3 startPos, Vector3 endPos){
       
       float time = 0;
       while (time < 1){
        time+=speed * Time.deltaTime;
        obj.position = Vector3.Lerp(startPos,endPos,time);

        yield return new WaitForEndOfFrame();
       
       }
       
        yield return null;
    }
}
