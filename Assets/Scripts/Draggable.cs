using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Proyecto26;     // for Firebase
using System.Text;   // for Encoding

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
    public Transform parentToReturnTo;
    public Transform parent;
    public TextAsset TextFile;
    public bool draggable = true;
    public int popularity;

    public string ServiceUUID = "FFE0";
    public string Characteristic = "FFE1";
    public static string _hm10;

    public void OnBeginDrag(PointerEventData eventData){
        var data = Encoding.UTF8.GetBytes ("w");          // 
        BluetoothLEHardwareInterface.WriteCharacteristic (_hm10, ServiceUUID, Characteristic, data, data.Length, false, (characteristicUUID) => {
            BluetoothLEHardwareInterface.Log ("Write Succeeded");
        });

        if (parentToReturnTo.name == "Play"){
            eventData.pointerDrag = null;
        }
        else if (!draggable){
            eventData.pointerDrag = null;
        }
        else{
            parent = this.transform.parent;
            this.transform.SetParent(parent.parent);
        }
    }

    public void OnDrag(PointerEventData eventData){
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData){
        this.transform.SetParent(parentToReturnTo);
    }

    public int getPopularity(){
        return popularity;
    }

    public string getTitle(){
        return TextFile.name;
    }

    public void RetrieveFromDatabase(){
        Song song = new Song();
        RestClient.Get<Song>("https://pico-86a8b.firebaseio.com/" + TextFile.name + ".json").Then(response =>{
            song = response;
            popularity = song.getPopularity();   //update values
        });
    }
}