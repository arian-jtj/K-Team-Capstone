using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionForMovingPlatform : MonoBehaviour
{
    [SerializeField] private DoorActiveStatus doorStatus;
    private SpriteRenderer _sprite;
    private Collider2D _collider;

    private void Start()
    {
        _sprite = gameObject.GetComponent<SpriteRenderer>();
        _collider = gameObject.GetComponent<Collider2D>();
    }

    void Update()
    {
        if(doorStatus.isDoorCurrentlyActive == false)
        {
            _sprite.enabled = true;
            _collider.enabled = true;
        }
        else
        {
            _sprite.enabled = false;
            _collider.enabled = false;
        }
    }
}
