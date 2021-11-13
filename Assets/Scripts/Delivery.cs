using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] private float destroyPackageDelay = .5f;
    [SerializeField] private Color32 carColourWithPackage = new Color32(255, 255, 0, 255);
    [SerializeField] private Color32 carColourWithoutPackage = new Color32(255, 255, 255, 255);

    private SpriteRenderer _spriteRenderer;
    
    private bool _hasPackage;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Package") && !_hasPackage)
        {
            Debug.Log("Picked up package.");
            _hasPackage = true;
            _spriteRenderer.color = carColourWithPackage;
            Destroy(other.gameObject, destroyPackageDelay);
        }
        else if (other.gameObject.CompareTag("Customer") && _hasPackage)
        {
            Debug.Log("Package delivered.");
            _spriteRenderer.color = carColourWithoutPackage;
            _hasPackage = false;
        }
    }
}