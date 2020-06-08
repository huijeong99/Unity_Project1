using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    //private Renderer bMaterial;
    public float speed = 0.5f;
    //public Vector2 offSet = new Vector2(0, 0);

    Material mat;

    private void Start()
    {
        //bMaterial = transform.GetComponent<Renderer>();

        //mat = GetComponent<Renderer>().material;
        //== 
        mat = GetComponent<MeshRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        //speed += Time.deltaTime * speed;
        //offSet += Vector2.up * speed * Time.deltaTime;
        //bMaterial.material.SetTextureOffset("_MainTex", offSet);

        Vector2 offSet = mat.mainTextureOffset;
        offSet.Set(0, offSet.y + speed * Time.deltaTime);
        mat.mainTextureOffset = offSet;
    }
}
