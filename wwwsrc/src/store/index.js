import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    publicKeeps: [],
    activeKeep: {}
  },
  mutations: {
    setPublickeeps(state, keeps) {
      state.publicKeeps = keeps
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
    },
    editKeep(state, updatedKeep) {
      debugger
      state.publicKeeps = state.publicKeeps.filter(k => k.id != updatedKeep.Id);
      state.publicKeeps.push(updatedKeep)
      state.activeKeep = updatedKeep
    },
    deleteKeep(state, id) {
      state.publicKeeps = state.publicKeeps.filter(k => k.id != id)
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
    async setActiveKeep({ commit, dispatch }, keep) {
      await commit("setActiveKeep", keep)

    },
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublickeeps", res.data);
    },
    async addKeep({ commit, dispatch }, newKeep) {
      try {
        let res = api.post('keeps', newKeep)
        dispatch("getPublicKeeps")
      } catch (error) {
        console.error(error);
      }
    },
    async editKeep({ commit, dispatch }, newEdit) {
      try {
        let res = await api.put("/keeps/" + newEdit.Id, newEdit);
        let updatedKeep = res.data;
        commit("editKeep", updatedKeep)
        router.push({ name: "Home" })
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeep({ commit, dispatch }, id) {
      try {
        let res = await api.delete("/keeps/" + id)
        commit("deleteKeep", id)
        router.push({ name: "Home" })
      } catch (error) {
        console.error(error);
      }
    },
    // async addView({ commit, dispatch }, id, views) {
    //   debugger
    //   try {
    //     let modViews = views + 1;
    //     let res = await api.put("/keeps/" + id, modViews)
    //   }
    //   catch (error) {
    //     console.error(error)
    //   }
    // }
  }
});
