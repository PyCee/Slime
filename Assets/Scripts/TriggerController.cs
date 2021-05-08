using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TriggerController : MonoBehaviour
{
    abstract public void TriggerAction(GameObject triggerer);
}
