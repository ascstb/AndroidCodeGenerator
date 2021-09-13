package com.r2devpros.mytestapp.presentation.base

import androidx.databinding.ObservableBoolean
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.Job
import timber.log.Timber
import kotlin.coroutines.CoroutineContext

class BaseViewModel(
    private val baseContext: CoroutineContext = Dispatchers.IO
) : ViewModel(), CoroutineScope {

    private val job: Job = Job()

    override val coroutineContext: CoroutineContext
        get() = baseContext + job

    override fun onCleared() {
        try {
            super.onCleared()
            job.cancel()
        } catch (e: Exception) {
            Timber.d("BaseViewModel_TAG: onCleared: exception: $e")
        }
    }

    val loading = ObservableBoolean(true)
    val loadingMessage = MutableLiveData("")
}