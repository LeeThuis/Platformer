using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGsManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] BGs;
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    Vector2 _movement = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LoopingBGs();
    }

    private void LoopingBGs()
    {

        for (int i = 0; i < BGs.Length; i++)
        {
            //BGs[i].transform.Translate(_movement * (_speed + i) * Time.deltaTime);
            if (Mathf.Abs(_player.position.x - BGs[i].transform.position.x) >= BGs[i].sprite.texture.width/10f)
            {
                BGs[i].transform.position = _player.transform.position;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        BGs = this.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < BGs.Length; i++)
        {
            BGs[i].sortingLayerName = "BG";
            BGs[i].sortingOrder = i;
        }
    }
}
