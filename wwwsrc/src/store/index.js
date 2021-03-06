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
    userVaults: [],
    activeKeep: {},
    userKeeps: []
  },
  mutations: {
    setPublickeeps(state, keeps) {
      state.publicKeeps = keeps
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep
    },
    setVaults(state, vaults) {
      state.userVaults = vaults;
    },
    setUserKeeps(state, keeps) {
      state.userKeeps = keeps;
    },
    editKeep(state, updatedKeep) {
      state.publicKeeps = state.publicKeeps.filter(k => k.id != updatedKeep.Id);
      state.publicKeeps.push(updatedKeep)
      state.activeKeep = updatedKeep
    },
    deleteKeep(state, id) {
      state.publicKeeps = state.publicKeeps.filter(k => k.id != id)
    },
    deleteVault(state, id) {
      state.userVaults = state.userVaults.filter(v => v.id != id)
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
      await dispatch("addView", keep)
      await commit("setActiveKeep", keep)
    },
    async getPublicKeeps({ commit, dispatch }) {
      let res = await api.get("keeps");
      commit("setPublickeeps", res.data);
    },
    async getVaults({ commit, dispatch }) {
      let res = await api.get("vaults")
      commit("setVaults", res.data);
    },
    async getKeepsByVault({ commit, dispatch }, id) {
      let res = await api.get("vaults/" + id + "/keeps")
      commit("setPublickeeps", res.data)
    },
    async getUserKeeps({ commit, dispatch }) {
      let res = await api.get("keeps/mykeeps")
      commit("setUserKeeps", res.data)
    },
    async addKeep({ commit, dispatch }, newKeep) {
      try {
        let res = api.post('keeps', newKeep)
        dispatch("getPublicKeeps")
      } catch (error) {
        console.error(error);
      }
    },
    async addVault({ commit, dispatch }, newVault) {
      try {
        let res = await api.post('vaults', newVault)
        commit("setVaults")
      } catch (error) {
        console.error(error)
      }
    },
    async addToVault({ commit, dispatch }, newSave) {
      try {
        let res = await api.post('vaultkeeps', newSave)
      } catch (error) {
        console.error(error)
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
    async deleteVault({ commit, dispatch }, id) {
      try {
        let res = await api.delete("/vaults/" + id)
        commit("deleteVault", id)
      } catch (error) {
        console.error(error);
      }
    },
    async addView({ commit, dispatch }, keep) {
      debugger
      try {
        let modViews = keep.Views + 1;
        let res = await api.put("/keeps/" + keep.Id, { Views: modViews, UserId: keep.UserId, Id: keep.Id, Img: keep.Img, Description: keep.Description, Name: keep.Name })
        // commit("setActiveKeep", res.data)
      }
      catch (error) {
        console.error(error)
      }
    }
  }
});
