uniform sampler2D texture;
uniform vec2 scale;
uniform vec4 color;

vec2 translate() {
    float border = 0.3;
    if (gl_TexCoord[0].x <= border / scale.x && gl_TexCoord[0].y <= border / scale.y) {
        return vec2(gl_TexCoord[0].x * scale.x, gl_TexCoord[0].y * scale.y);
    }
    if (gl_TexCoord[0].x <= border / scale.x && gl_TexCoord[0].y >= (1 - border / scale.y)) {
        return vec2(gl_TexCoord[0].x * scale.x, 1 - ((1 - gl_TexCoord[0].y) * scale.y));
    }
    if (gl_TexCoord[0].x <= border / scale.x) {
        return vec2(gl_TexCoord[0].x * scale.x, 0.5);
    }
    if (gl_TexCoord[0].x >= (1 - border / scale.x) && gl_TexCoord[0].y <= border / scale.y) {
        return vec2(1 - ((1 - gl_TexCoord[0].x) * scale.x), gl_TexCoord[0].y * scale.y);
    }
    if (gl_TexCoord[0].x >= (1 - border / scale.x) && gl_TexCoord[0].y >= (1 - border / scale.y)) {
        return vec2(1 - ((1 - gl_TexCoord[0].x) * scale.x), 1 - ((1 - gl_TexCoord[0].y) * scale.y));
    }
    if (gl_TexCoord[0].x >= (1 - border / scale.x)) {
        return vec2(1 - ((1 - gl_TexCoord[0].x) * scale.x), 0.5);
    }
    if (gl_TexCoord[0].y <= border / scale.y) {
        return vec2(0.5, gl_TexCoord[0].y * scale.y);
    }
    if (gl_TexCoord[0].y >= (1 - border / scale.y)) {
        return vec2(0.5, 1 - ((1 - gl_TexCoord[0].y) * scale.y));
    }
    return vec2(0.5, 0.5);
}

void main() {
    vec4 pixel = texture2D(texture, translate());
    gl_FragColor = pixel * color;
}