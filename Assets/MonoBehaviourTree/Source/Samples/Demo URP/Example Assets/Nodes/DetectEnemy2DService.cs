using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MBT;

namespace MBTExample
{
    [AddComponentMenu("")]
    [MBTNode("Example/Detect Enemy 2D Service")]
    public class DetectEnemy2DService : Service
    {
        public LayerMask mask = -1;
        [Tooltip("Circle radius")]
        public FloatReference range ;
        public TransformReference variableToSet = new TransformReference(VarRefMode.DisableConstant);

        public override void Task()
        {
            // Find target in radius and feed blackboard variable with results
            Collider[] colliders = Physics.OverlapSphere(transform.position, range.Value, mask);
            if (colliders.Length > 0)
            {
                variableToSet.Value = colliders[colliders.Length-1].transform;
            }
            else
            {
                variableToSet.Value = null;
            }
        }
    }
}
