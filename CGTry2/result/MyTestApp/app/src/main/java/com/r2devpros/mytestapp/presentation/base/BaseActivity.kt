package com.r2devpros.mytestapp.presentation.base

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.databinding.DataBindingUtil
import androidx.databinding.ViewDataBinding
import androidx.databinding.library.baseAdapters.BR
import com.r2devpros.mytestapp.R
import com.r2devpros.mytestapp.presentation.navigation.Navigation
import org.koin.android.ext.android.inject
import timber.log.Timber
import java.util.*

abstract class BaseActivity : AppCompatActivity() {
    //region Variables
    protected val navigation by inject<Navigation>()
    protected lateinit var binding: ViewDataBinding
    private var vm: BaseViewModel? = null
    //endregion

    //region Life Cycle
    override fun onCreate(savedInstanceState: Bundle?) {
        Timber.d("BaseActivity_TAG: onCreate: ")
        super.onCreate(savedInstanceState)
    }
    //endregion

    //region Functions
    protected fun setBinding(
        activity: AppCompatActivity,
        layoutId: Int,
        viewModel: BaseViewModel
    ): ViewDataBinding {
        Timber.d("BaseActivity_TAG: setBinding: ")
        vm = viewModel

        binding = DataBindingUtil.setContentView(activity, layoutId)
        binding.lifecycleOwner = activity
        binding.setVariable(BR.viewModel, viewModel)

        viewModel.loading.set(true)
        viewModel.loadingMessage.postValue(getString(R.string.initial_loading_message))

        return binding
    } 
    //endregion

    //region Events
    override fun onBackPressed() {
        Timber.d("BaseActivity_TAG: onBackPressed: ")
        navigation.goBack(this) { super.onBackPressed() }
    }
    //endregion
}