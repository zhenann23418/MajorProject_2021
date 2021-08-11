using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//add Using TMPRO since we are using TextMeshPro
using TMPro;

//How TextMeshPro works: 
//TextMeshPro works by creating one little, four vertex mesh per character
//so what we need to do in this script is to intercept those generated meshes and modify
//them to create the desired text effect (wobbly text) 

public class WobblyText : MonoBehaviour
{
    //define the variables
    public TMP_Text textComponent;

    // Update is called once per frame
    void Update()
    {
        //ForceMeshUpdate is to ensure that the meshes within TMP are updated
        textComponent.ForceMeshUpdate();

        //then we store textComponent.textInfo in a variable because we are going to use it a lot
        var textInfo = textComponent.textInfo;

        //then we create a for loop where one loop is for each character in the sentence
        //and you can use i to apply different effects per-character
        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            //then we will store textInfo.characterInfo into a variable because it is also going to be
            //used a lot 
            var charInfo = textInfo.characterInfo[i];

            //then we will check if there are any invisible characters within the sentence
            //so we can skip those, by using if charInfo.isVisible =  false
            if(!charInfo.isVisible)
            {
                continue;
            }

            //now we take the vertices form the mesh associated with the current character's material 
            //and put them in a variable called verts
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            //then create a loop where j goes from 0 - 3, one loop for each of the four vertices of the
            //character
            for (int j = 0; j < 4; ++j)
            {
                //then store the current position of that vertex by indexing verts at charInfo.vertexIndex
                // + j
                var orig = verts[charInfo.vertexIndex + j];
                //then override the array with a modified version 
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10f, 0);

            }
        }

        //Now we need to update the working copy 
        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
