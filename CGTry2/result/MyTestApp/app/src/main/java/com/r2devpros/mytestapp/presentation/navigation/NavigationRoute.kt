package com.r2devpros.mytestapp.presentation.navigation

enum class NavigationRoute(val innerLink: String) {
    SPLASH_SCREEN("splash-screen"),
    HOME("home"),
    NOT_FOUND("")
    ;

    companion object {
        fun getByInnerLink(innerLink: String) =
            values().firstOrNull { it.innerLink == innerLink } ?: NOT_FOUND
    }
}