<template>
  <div class="col-6 col-md-4">
    <div class="card">
      <router-link
        :to="{name: 'VaultDetails', params: {id: this.vaultData.id, name: this.vaultData.name}}"
      >
        <img class="card-img-top" src="https://picsum.photos/200/300" alt />
        <div class="card-body">
          <h4 class="card-title">{{vaultData.name}}</h4>
          <p class="card-text">{{vaultData.description}}</p>
          <p class="text-center">Keeps: {{}}</p>
          <button @click="deleteVault" title="Delete this Vault" class="btn btn-danger">X</button>
        </div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "Vault",
  props: ["vaultData"],
  computed: {},
  methods: {
    deleteVault() {
      this.$store.dispatch("deleteVault", this.vaultData.id);
    }
  }
};
</script>

<style scoped>
</style>