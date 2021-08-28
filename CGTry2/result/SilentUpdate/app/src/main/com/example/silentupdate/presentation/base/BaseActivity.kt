package com.example.silentupdate.presentation.base

import androidx.appcompat.app.AppCompatActivity
import androidx.databinding.DataBindingUtil
import androidx.databinding.ViewDataBinding
import androidx.databinding.library.baseAdapters.BR
import com.example.silentupdate.core.Session
import com.example.silentupdate.presentation.navigation.Navigation
import com.example.silentupdate.presentation.utils.isConnectedToInternet
import org.koin.android.ext.android.inject
import timber.log.Timber

abstract class BaseActivity : AppCompatActivity() {
    protected val navigation by inject<Navigation>()
    protected lateinit var binding: ViewDataBinding

    protected fun setBinding(activity: AppCompatActivity, layoutId: Int, viewModel: BaseViewModel) : ViewDataBinding {
        Timber.d("BaseActivity_TAG: setBinding: ")

        binding = DataBindingUtil.setContentView(activity, layoutId)
        binding.lifecycleOwner = activity
        binding.setVariable(BR.viewModel, viewModel)
        
        Session.currentActivity = activity
        Session.currentViewModel = viewModel
        viewModel.loading = true

        isConnectedToInternet()

        return binding
    }

    override fun onBackPressed() {
        navigation.navigateBack(this) { super.onBackPressed() }
    }

    private fun setFocusListener(v: View, hasFocus: Boolean) {
        if (originalConnectivityBackground == null) originalConnectivityBackground = v.background

        originalConnectivityBackground?.let {
            v.onViewFocused(
                hasFocus = hasFocus,
                originalBackground = it
            )
        }
    }
}