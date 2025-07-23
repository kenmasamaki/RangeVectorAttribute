# RangeVectorAttribute

RangeVectorAttributeは、Unityのインスペクター上でVector型（Vector2, Vector3, Vector4, Vector2Int, Vector3Int）の各成分を指定の範囲で制限できるカスタム属性です。  
`RangeVector`属性をフィールドに付与することで、各成分ごとに指定した範囲で値を調整できるようになります。

![Image](https://github-production-user-asset-6210df.s3.amazonaws.com/124390814/469567962-289717c2-fed1-4d4a-a6ef-152af5d9cbd7.png?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=AKIAVCODYLSA53PQK4ZA%2F20250723%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20250723T052901Z&X-Amz-Expires=300&X-Amz-Signature=4d5ca691b5a6877106ac14f3810f77cec085a18ed7541bc525171bbb8a5e57da&X-Amz-SignedHeaders=host)

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
