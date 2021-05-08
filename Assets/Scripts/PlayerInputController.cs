using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public GameObject[] controllableCharacters;
    private MovementController _movementController;
    private AttackController _attackController;

    private class GameObjectEnumerator : IEnumerator<GameObject> {
        private GameObject[] _collection;
        private int currIndex;
        private GameObject currGameObject;
        private bool _loop = true;

        public delegate void IndexFunction(GameObject currGameObject);
        private IndexFunction _preIndexFunction;
        private IndexFunction _postIndexFunction;

        public GameObjectEnumerator(GameObject[] collection, IndexFunction preIndexFunction, IndexFunction postIndexFunction) {
            _collection = collection;
            currIndex = -1;
            currGameObject = default(GameObject);
            _preIndexFunction = preIndexFunction;
            _postIndexFunction = postIndexFunction;
        }
        private void Index(){
            if(currGameObject){
                _preIndexFunction(currGameObject);
            }
            currGameObject = _collection[currIndex];
            _postIndexFunction(currGameObject);
        }
        public bool MoveNext(){
            currIndex++;
            if (currIndex >= _collection.Length){
                if(_loop == false){
                    return false;
                } else {
                    currIndex = 0;
                }
            }
            Index();
            return true;
        }
        public void Reset() { currIndex = -1; }
        void IDisposable.Dispose() { }
        public GameObject Current { get { return currGameObject; } }
        object IEnumerator.Current{ get { return Current; } }
        public bool Set(String gameObjectName){
            for(int i = 0; i < _collection.Length; i++){
                if(_collection[i].name == gameObjectName){
                    // TODO: change name comparison to function
                    currIndex = i;
                    Index();
                    return true;
                }
            }
            return false;
        }
    }

    GameObjectEnumerator selectedCharacter;
    public void PreCharacterChange(GameObject currCharacter){
        _movementController.SetMovement(new Vector2(0.0f, 0.0f));
    }
    public void PostIndexCharacters(GameObject currCharacter){
        print(currCharacter.name);
        _movementController = currCharacter.GetComponent<MovementController>();
        _attackController = currCharacter.GetComponent<AttackController>();

        // TODO: inherit movement
    }

    void Start(){
        selectedCharacter = new GameObjectEnumerator(controllableCharacters, PreCharacterChange, PostIndexCharacters);
        selectedCharacter.MoveNext();
    }

    public void IncrementCharacterSelection(InputAction.CallbackContext context){
        if(context.performed == true){
            selectedCharacter.MoveNext();
        }
    }
    public void Attack(InputAction.CallbackContext context){
        if(context.performed == true){
            if(_attackController){
                _attackController.Attack();
            }
        }
    }
    public void Move(InputAction.CallbackContext context){
        if(_movementController){
            Vector2 movementDir = context.ReadValue<Vector2>();
            _movementController.SetMovement(movementDir);
        }
    }
}
