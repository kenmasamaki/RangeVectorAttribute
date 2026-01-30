# RangeVectorAttribute

RangeVectorAttributeは、Unityのインスペクター上でVector型（Vector2, Vector3, Vector4, Vector2Int, Vector3Int）の各成分を指定の範囲で制限できるカスタム属性です。  
`RangeVector`属性をフィールドに付与することで、各成分ごとに指定した範囲で値を調整できるようになります。

<img width="50%" alt="スクリーンショット 2026-01-30 110924" src="https://github.com/user-attachments/assets/42cbfd60-335e-4c44-9b35-ba1f9bf232a9" />


## 特長

- Vector型の各成分に範囲付きスライダーを表示
- `Vector2`, `Vector3`, `Vector4`, `Vector2Int`, `Vector3Int`に対応
- 入力ミスを防ぎ、値の管理を効率化

## 使用例

```csharp
[RangeVector(0f, 1f)]
public Vector2 vector2;

[RangeVector(0f, 1f)]
public Vector3 vector3;

[RangeVector(0f, 1f)]
public Vector4 vector4;

[RangeVector(0, 1)]
public Vector2Int vector2Int;

[RangeVector(0, 10)]
public Vector3Int vector3Int;
```


上記のように、`RangeVector`属性を付与したフィールドはインスペクター上で範囲付きスライダーが表示され、各成分の値を簡単に調整できるようになります。
