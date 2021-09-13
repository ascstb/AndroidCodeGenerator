package com.r2devpros.mytestapp.presentation.navigation

import android.content.Context
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity

interface Navigation {
    fun goBack(fromActivity: AppCompatActivity, defaultBehavior: () -> Unit)
    fun goHome(fromActivity: AppCompatActivity, extras: Bundle? = null)
    fun goToSplash(fromActivity: AppCompatActivity, extras: Bundle? = null)
    fun goToLink(context: Context, link: String, extras: Bundle? = null)
    fun goTo(fromActivity: AppCompatActivity, to: NavigationRoute, extras: Bundle? = null)
}