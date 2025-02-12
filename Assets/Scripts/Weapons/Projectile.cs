using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   [Header("Projectile Settings")]
   [SerializeField] private float speed;

   public Vector3 direction { get; set; }
   public float damage { get; set; }

   private void Update()
   {
      transform.Translate(direction * (speed * Time.deltaTime));
   }
   
   private void OnTriggerEnter2D(Collider2D other)
   { 
     other.GetComponent<IDamageable>()?.TakeDamage(damage);
     Destroy(gameObject);
   }
   
}
