using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
    [Tooltip("Base Movement Speed"), Min(0.0f)]
    public float movementSpeed;

    private Vector2 _movementDir;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool _facingRight;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _movementDir = new Vector2(0.0f, 0.0f);
    }
    void FixedUpdate(){
        rb.MovePosition(rb.position + _movementDir * movementSpeed * Time.fixedDeltaTime);
    }
    public void SetMovement(Vector3 movementDir){
        _movementDir = movementDir;

        if(_movementDir.x > 0.0f) _facingRight = true;
        else if(_movementDir.x < 0.0f) _facingRight = false;

        spriteRenderer.flipX = !_facingRight;
    }
}
