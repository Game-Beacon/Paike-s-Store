using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class CharacterGetSprite : MonoBehaviour
{
    public Sprite A;
    private void Start() {
        GetComponent<Character>().NameImage = A;
    }
}
