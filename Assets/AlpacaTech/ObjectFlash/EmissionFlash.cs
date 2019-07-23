using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialInfo
{
    public Material material;
    public Color colorDefault;
};

/// <summary>
/// 一瞬だけ白くする
/// Emissionにチェックが入っていること
/// 
/// 
/// </summary>
public class EmissionFlash : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Color colorFlash = new Color(0.5f, 0.5f, 0.5f);
    [SerializeField] private int flashCount = 0;
    [SerializeField] private bool enumChildren = true;
    [SerializeField] private List<MaterialInfo> materials = new List<MaterialInfo>();
    [SerializeField] private bool EnumOnAwake = true;


    /// <summary>
    /// 起動時にMaterialを列挙
    /// </summary>
    void Awake()
    {
        if(!target)
        {
            target = this.gameObject;
        }

        CheckMaterial(target);

        if (enumChildren)
        {
            GetChildren(target);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="m"></param>
    void AddMaterial(Material m)
    {
        var info = new MaterialInfo();
        info.colorDefault = m.GetColor("_EmissionColor");
        info.material = m;
        materials.Add(info);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    void CheckMaterial(GameObject obj)
    {
        var r = obj.GetComponent<Renderer>();
        if (r)
        {
            AddMaterial(r.material);
        }

        var smr = obj.GetComponent<SkinnedMeshRenderer>();
        if (smr)
        {
            foreach (var m in smr.materials)
            {
                AddMaterial(m);
            }
        }
    }

    //  子要素を取得してリストに追加
    public void GetChildren(GameObject obj)
    {
        var children = obj.GetComponentInChildren<Transform>();
        foreach (Transform ob in children)
        {
            CheckMaterial(ob.gameObject);
            GetChildren(ob.gameObject);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="count"></param>
    public void setFlash(int count=1)
    {
        flashCount = count;
        foreach(var info in materials)
        {
            info.material.SetColor("_EmissionColor", colorFlash);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void Update ()
    {
        if(flashCount>0)
        {
            foreach (var info in materials)
            {
                info.material.SetColor("_EmissionColor", colorFlash);
            }
        }
        else if (flashCount== 0)
        {
            foreach (var info in materials)
            {
                info.material.SetColor("_EmissionColor", info.colorDefault);
            }
        }
        flashCount--;
    }
}
