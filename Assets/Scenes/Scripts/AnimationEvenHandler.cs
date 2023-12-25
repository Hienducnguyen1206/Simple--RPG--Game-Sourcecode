using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public GameObject objectToDestroy; 

     public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Buried2") && stateInfo.normalizedTime >= 1.0f)
        {
            if (objectToDestroy != null)
            {
                Debug.Log("Object destroyed after Buried2 animation");
                Destroy(objectToDestroy);
            }
            else
            {
                Debug.LogWarning("No object assigned to destroy!");
            }
        }
    }
}
