package com.r2devpros.mytestapp.presentation.base

import android.os.Bundle
import androidx.fragment.app.Fragment

interface BaseFragmentListener {
    fun onFocused()
    fun onClicked(fromFragment: Fragment, extras: Bundle? = null)
}