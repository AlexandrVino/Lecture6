using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{

    [SerializeField] private Renderer[] _renderers;

    public void SetMaterial(Material material) {
        foreach (var item in _renderers) item.material = material;
    }

}
