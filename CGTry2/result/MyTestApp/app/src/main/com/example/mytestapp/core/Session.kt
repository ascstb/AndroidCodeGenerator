package com.example.mytestapp.core

import androidx.fragment.app.Fragment
import androidx.appcompat.app.AppCompatActivity
import com.example.mytestapp.presentation.base.BaseViewModel

object Session {
    var currentFragment: Fragment? = null
    var currentActivity: AppCompatActivity? = null
    var currentViewModel: BaseViewModel? = null
}