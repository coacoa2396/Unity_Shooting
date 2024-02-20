using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeController : MonoBehaviour
{

    [SerializeField] Target target;
    [SerializeField] Transform[] closedTargets;
    [SerializeField] Transform[] middleTargets;
    [SerializeField] Transform[] longTargets;




    private void Awake()
    {
        StartCoroutine(ShootingTraining());
    }

    int RandomNum() 
    {
        int num = Random.Range(0, 3);

        return num;
    }



    IEnumerator ShootingTraining()
    {
        yield return new WaitForSeconds(5f);

        Instantiate(target, longTargets[RandomNum()].transform.position, Quaternion.identity); //멀
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, closedTargets[RandomNum()].transform.position, Quaternion.identity); //가
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, middleTargets[RandomNum()].transform.position, Quaternion.identity); //중
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, longTargets[RandomNum()].transform.position, Quaternion.identity); //멀
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, closedTargets[RandomNum()].transform.position, Quaternion.identity); //가
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, middleTargets[RandomNum()].transform.position, Quaternion.identity); //중
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, longTargets[RandomNum()].transform.position, Quaternion.identity); //멀
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, middleTargets[RandomNum()].transform.position, Quaternion.identity); //중
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, closedTargets[RandomNum()].transform.position, Quaternion.identity); //가
        

        yield return new WaitForSeconds(8f);

        Instantiate(target, middleTargets[RandomNum()].transform.position, Quaternion.identity); //중
        

    }
}
