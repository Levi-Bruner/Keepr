import Vue from "vue";
import Router from "vue-router";
// @ts-ignore
import Home from "./views/Home.vue";
// @ts-ignore
import KeepDetails from "./components/KeepDetails"
// @ts-ignore
import Dashboard from "./views/Dashboard.vue";
// @ts-ignore
import VaultDetails from "./views/VaultDetails"
import { authGuard } from "@bcwdev/auth0-vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "home",
      component: Home
    },
    {
      path: "/:id",
      name: "KeepDetails",
      component: KeepDetails,
      beforeEnter: authGuard
    },
    {
      path: "/dashboard",
      name: "dashboard",
      component: Dashboard,
      beforeEnter: authGuard
    },
    {
      path: "/dashboard/:id",
      name: "VaultDetails",
      component: VaultDetails,
      beforeEnter: authGuard
    }
  ]
});
