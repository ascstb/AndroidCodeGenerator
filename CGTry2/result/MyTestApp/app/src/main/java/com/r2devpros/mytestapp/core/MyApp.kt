package com.r2devpros.mytestapp.core

import android.app.Application
import com.r2devpros.mytestapp.BuildConfig
import com.r2devpros.mytestapp.di.*
import org.koin.android.ext.koin.androidContext
import org.koin.android.ext.koin.androidLogger
import org.koin.core.context.startKoin
import org.koin.core.logger.Level
import timber.log.Timber

class MyApp : Application() {
    override fun onCreate() {
        super.onCreate()

        if (BuildConfig.DEBUG)
            Timber.plant(Timber.DebugTree())

        Timber.d("MyApp_TAG: onCreate: ")

        startKoin {
            if (BuildConfig.DEBUG) androidLogger(Level.ERROR)

            androidContext(this@MyApp)
            modules(
                        navigationModules +
                        apiModule +
                        presentationModule +
                        localModule
            )
        }
    }
}