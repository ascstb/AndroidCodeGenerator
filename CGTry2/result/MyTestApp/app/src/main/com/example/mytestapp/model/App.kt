package com.example.mytestapp.model

import android.os.Parcelable
import kotlinx.android.parcel.Parcelize

@Parcelize
data class App(
	var appId: String,
	var groups: Object[],
	var name: String,
	var deepLink: String,
	var iconUrl: String,
	var iconResourceName: String,
	var adminApp: Boolean,
	var order: Int
) : Parcelable