#ifndef __RGB_YUV__
#define __RGB_YUV__

#include "UnityCG.cginc"

inline fixed RGB2Y(fixed3 rgb) {
	return dot(rgb, fixed3(0.29900, 0.58700, 0.11400));
}

inline fixed RGB2U(fixed3 rgb) {
	return dot(rgb, fixed3(-0.14713, -0.28886, 0.43600));
}

inline fixed RGB2V(fixed3 rgb) {
	return dot(rgb, fixed3(0.61500, -0.51499, -0.10001));
}

fixed3 RGB2YUV(fixed3 rgb) {
	fixed3 yuv;
	yuv.r = RGB2Y(rgb);
	yuv.g = RGB2U(rgb);
	yuv.b = RGB2V(rgb);

	return yuv;
}

inline fixed YUV2R(fixed3 yuv) {
	return dot(yuv, fixed3(1, 0.00000, 1.13983));
}

inline fixed YUV2G(fixed3 yuv) {
	return dot(yuv, fixed3(1.0, -0.39465, -0.58060));
}

inline fixed YUV2B(fixed3 yuv) {
	return dot(yuv, fixed3(1.0, 2.03211, 0.00000));
}

fixed3 YUV2RGB(fixed3 yuv) {
	fixed3 rgb;
	rgb.r = YUV2R(yuv);
	rgb.g = YUV2G(yuv);
	rgb.b = YUV2B(yuv);

	return rgb;
}

#endif // __RGB_YUV__
