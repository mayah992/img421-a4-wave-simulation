using Unity.VisualScripting;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    public void LetsGo()
    {
        GameObject current = this.GameObject();
        current.SetActive(false);
    }
}
