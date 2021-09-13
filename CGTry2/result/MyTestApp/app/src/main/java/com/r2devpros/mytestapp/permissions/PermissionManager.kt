package com.r2devpros.mytestapp.permissions

import android.Manifest
import android.content.pm.PackageManager
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import com.r2devpros.mytestapp.core.REQUEST_SEVERAL_PERMISSIONS
import timber.log.Timber

object PermissionManager {
    fun checkPermission(
        context: AppCompatActivity,
        permissions: List<Permissions>,
        onPermissionResult: (Int, Boolean) -> Unit
    ) {
        val requestPermissions = mutableListOf<String>()

        permissions.forEach { permission ->
            if (ContextCompat.checkSelfPermission(
                    context,
                    permission.manifestPermission
                ) != PackageManager.PERMISSION_GRANTED
            ) {
                requestPermissions.add(permission.manifestPermission)
            } else {
                Timber.d("PermissionManager_TAG: checkPermission: permission granted")
                onPermissionResult(permission.code, true)
            }
        }

        if (requestPermissions.isNotEmpty()) {
            ActivityCompat.requestPermissions(
                context,
                requestPermissions.toTypedArray(),
                REQUEST_SEVERAL_PERMISSIONS
            )
        }
    }

    fun checkResults(
        requestCode: Int, permissions: Array<out String>, grantResults: IntArray,
        onPermissionResult: (Boolean) -> Unit
    ) {
        Timber.d("PermissionManager_TAG: checkResults: requestCode: $requestCode")
        when (requestCode) {
            Permissions.STORAGE.code -> {
                Timber.d("PermissionManager_TAG: checkResults: Storage Permission")
                if (grantResults.isNotEmpty() && grantResults.first() == PackageManager.PERMISSION_GRANTED) {
                    Timber.d("PermissionManager_TAG: checkResults: Permission Granted")
                    onPermissionResult(true)
                } else {
                    Timber.d("PermissionManager_TAG: checkResults: Permission Denied")
                    onPermissionResult(false)
                }
            }
            Permissions.WIFI.code -> {
                Timber.d("PermissionManager_TAG: checkResults: Wifi permission")
                if (grantResults.isNotEmpty() && grantResults.first() == PackageManager.PERMISSION_GRANTED) {
                    Timber.d("PermissionManager_TAG: checkResults: Permission Granted")
                    onPermissionResult(true)
                } else {
                    Timber.d("PermissionManager_TAG: checkResults: Permission Denied")
                    onPermissionResult(false)
                }
            }
            REQUEST_SEVERAL_PERMISSIONS -> {
                Timber.d("PermissionManager_TAG: checkResults: permissions: ${permissions.joinToString(separator = ",")}")
                val allPermissionsGranted = grantResults.all { it == PackageManager.PERMISSION_GRANTED }

                onPermissionResult(allPermissionsGranted)
            }
        }
    }
}