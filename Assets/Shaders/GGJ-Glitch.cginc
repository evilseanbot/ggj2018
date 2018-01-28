
//https://answers.unity.com/questions/399751/randomity-in-cg-shaders-beginner.html
float rand(float3 co)
{
	return frac(sin(dot(co.xyz, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
}

//https://www.laurivan.com/rgb-to-hsv-to-rgb-for-shaders/
float3 hsv2rgb(float3 c)
{
	float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
	float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
	return c.z * lerp(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

//http://www.neilmendoza.com/glsl-rotation-about-an-arbitrary-axis/
float4x4 rotationMatrix(float3 axis, float angle)
{
	axis = normalize(axis);
	angle /= 180;
	float s = sin(angle);
	float c = cos(angle);
	float oc = 1.0 - c;

	return float4x4(oc * axis.x * axis.x + c, oc * axis.x * axis.y - axis.z * s, oc * axis.z * axis.x + axis.y * s, 0.0,
		oc * axis.x * axis.y + axis.z * s, oc * axis.y * axis.y + c, oc * axis.y * axis.z - axis.x * s, 0.0,
		oc * axis.z * axis.x - axis.y * s, oc * axis.y * axis.z + axis.x * s, oc * axis.z * axis.z + c, 0.0,
		0.0, 0.0, 0.0, 1.0);
}