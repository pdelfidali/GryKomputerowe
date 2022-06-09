using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;

    private void Start(){
        templates = GameObject.FindGameObjectWithTag("Templates").GetComponent<RoomTemplates>();
        try{ 
            templates.levelList.list[templates.level].list.Add(this.gameObject);
        }
        catch (Exception e){
            ;
        }
    }
}
