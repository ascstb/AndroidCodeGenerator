package com.r2devpros.mytestapp.permissions

import android.Manifest

enum class Permissions(val code: Int, val manifestPermission: String) {
    STORAGE(code = 100, manifestPermission = Manifest.permission.WRITE_EXTERNAL_STORAGE),
    RECORD_AUDIO(code = 600, manifestPermission = Manifest.permission.RECORD_AUDIO),
    PHONE_STATE(code = 400, manifestPermission = Manifest.permission.READ_PHONE_STATE),
    TIMEZONE(code = 300, manifestPermission = Manifest.permission.SET_TIME_ZONE),
    WIFI(code = 200, manifestPermission = Manifest.permission.ACCESS_COARSE_LOCATION),
    CAMERA(code = 500, manifestPermission = Manifest.permission.CAMERA)
    ;

    companion object {
        fun fromCode(code: Int) = values().first { it.code == code }
    }
}