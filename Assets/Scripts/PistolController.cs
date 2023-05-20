using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.OpenXR.Input;

public class PistolController : MonoBehaviour
{
    [SerializeField] private int _ammo;
    [SerializeField] private int damage;
    //private int range = 100;
    private RaycastHit hit;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Shoot();
    }*/

    /*
    private void Shoot()
    {
        if()
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * range, Color.red, 1, false);
            
            
            DotSpawn.hitted = hit.transform.name;
            Target target = hit.transform.GetComponent<Target>();
            Dot dot = hit.transform.GetComponent<Dot>();
            Wood box = hit.transform.GetComponent<Wood>();
            */
            

            /*if (target != null)
            {
                target.TakeDamage(damage);*/

                /*spark_flesh.transform.position = hit.point;
                spark_flesh.transform.rotation = Quaternion.LookRotation(hit.normal);
                SparksFlesh.Play();*/



                // bulletimpact2 = GameObject.FindGameObjectsWithTag("trashf");
                // foreach(GameObject i in bulletimpact2){
                //     Destroy(i, lifeTimeFlesh);
                // }
            /*}*/
            // else if(dot !=null)
            // {
            //     dot.TakeDamage();
            //     // spark_metal.transform.position = hit.point;
            //     // spark_metal.transform.rotation = Quaternion.LookRotation(hit.normal);
            //     SparksMetal.Play();
            //     // Destroy(ddddddddddddddddddddddddspark_metal);
            // }
            //
            // else if(box !=null){
            //     spark_wood.transform.position = hit.point;
            //     spark_wood.transform.rotation = Quaternion.LookRotation(hit.normal);
            //     sparksWood.Play();
            // }
            //
            // else {
            //     clonem = Instantiate(spark_metal, hit.point, Quaternion.LookRotation(hit.normal)); 
            //     clonem.tag= "trashm";
            //     SparksMetal.Play();
            //     bulletimpact2 = GameObject.FindGameObjectsWithTag("trashm");
            //     foreach(GameObject i in bulletimpact2){
            //         Destroy(i, lifeTimeMetal);
            //     }
        
}
