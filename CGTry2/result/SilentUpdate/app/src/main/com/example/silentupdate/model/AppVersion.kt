package com.example.silentupdate.model

import android.os.Parcelable
import kotlinx.android.parcel.Parcelize

@Parcelize
data class AppVersion(
	var flavor: String,
	var latestVersion: String,
	var downloadUrl: String
) : Parcelable