using UnityEngine;

public class BaeItemView<T> : MonoBehaviour
{
    protected T Content;

    public virtual void SetupContent(T content)
    {
        Content = content;
    }
}
