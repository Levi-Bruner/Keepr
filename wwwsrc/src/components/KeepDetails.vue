<template>
  <div class="row justify-content-center">
    <div class="col-10 col-md-6">
      <div class="card bg-dark text-white">
        <img class="card-img" :src="activeKeep.Img" alt />
        <div class="card-body">
          <p class="card-title">{{activeKeep.Title}}</p>
          <p class="card-text text-center">{{activeKeep.Description}}</p>
          <p
            class="text-center"
          >Views: {{activeKeep.Views}} - Keeps: {{activeKeep.Keeps}} - Shares: {{activeKeep.Shares}}</p>
          <button @click="deleteKeep" title="Delete this Keep" class="btn btn-danger">X</button>
          <select v-model="vaultId">
            <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
          </select>
          <button @click="addToVault" class="btn btn-primary">Save</button>
          <div>
            <form @submit.prevent="editKeep">
              <input type="text" placeholder="name" v-model="activeKeep.Name" />
              <input type="text" placeholder="description" v-model="activeKeep.Description" />
              <button class="btn btn-secondary" title="Edit this Keep">E</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "KeepDetails",
  mounted() {
    return this.$store.dispatch("getVaults");
  },
  data() {
    return {
      vaultId: "",
      keepId: ""
    };
  },
  computed: {
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    vaults() {
      return this.$store.state.userVaults;
    }
  },
  methods: {
    editKeep() {
      let activeKeep = {
        Id: this.activeKeep.Id
      };
      this.$store.dispatch("editKeep", this.activeKeep);
    },
    deleteKeep() {
      this.$store.dispatch("deleteKeep", this.activeKeep.Id);
    },
    addToVault() {
      let newSave = {
        vaultId: this.vaultId,
        keepId: this.activeKeep.Id
      };
      this.$store.dispatch("addToVault", newSave);
    }
  }
};
</script>

<style scoped>
</style>