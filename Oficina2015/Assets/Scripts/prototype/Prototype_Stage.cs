using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class Prototype_Stage : MonoBehaviour {
    public enum Direction
    {
        Vertical,
        Horizontal
    }

    public static float Speed = 1;
    private const float SpeedMultiplier = .01f;
	public float customSpeed = 0;
    public Direction direction;
    [HideInInspector]
    public MeshRenderer meshRenderer;
    public bool RandomizePosition = false;
	// Use this for initialization
	void Start () {
        this.meshRenderer = this.GetComponent<MeshRenderer>();
        if (RandomizePosition)
        {
            Vector2 texOffset = this.meshRenderer.material.GetTextureOffset("_MainTex");
            this.meshRenderer.material.SetTextureOffset("_MainTex", new Vector2(Random.Range(0, 100)/100f, texOffset.y));
        }
	}

    void FixedUpdate()
    {
        Vector2 texOffset = this.meshRenderer.material.GetTextureOffset("_MainTex");
        this.meshRenderer.material.SetTextureOffset("_MainTex", texOffset + (direction == Direction.Horizontal ? -Vector2.right : Vector2.up) * (customSpeed != 0 ? customSpeed : Speed) * SpeedMultiplier);
    }
}
